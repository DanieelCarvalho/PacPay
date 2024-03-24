using MediatR;
using PacPay.App.Compartilhado.Utilitarios;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Entidades.Enums;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Historico
{
    public sealed class Historico(IAutenticador autenticador, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao) : IRequestHandler<HistoricoRequest, List<HistoricoResponse>>
    {
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;

        public async Task<List<HistoricoResponse>> Handle(HistoricoRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticador.PegarId());
            int numeroDaPagina = request.NumeroDaPagina;

            List<Operacao> lista = Operacao.Historico(id, numeroDaPagina, _repositorioOperacao, cancellationToken);

            List<HistoricoResponse> historicoResponses = [];

            foreach (Operacao operacao in lista)
            {
                string? cpfDestino = operacao.TipoOperacao.ToString() == Transacoes.Transferencia.ToString()
                                    ? await _repositorioConta.PegarCpf(operacao.IdContaDestino, cancellationToken)
                                    : null;

                HistoricoResponse historicoResponse = new()
                {
                    Valor = operacao.Valor,
                    TipoOperacao = operacao.TipoOperacao.ToString(),
                    CpfDestino = cpfDestino,
                    DataOperacao = FormatarData.ParaString(operacao.DataOperacao),
                    Descricao = operacao.Descricao
                };

                historicoResponses.Add(historicoResponse);
            }

            return historicoResponses;
        }
    }
}