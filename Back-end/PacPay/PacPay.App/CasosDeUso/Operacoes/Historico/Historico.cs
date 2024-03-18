using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Entidades.Enums;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Historico
{
    public sealed class Historico(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao) : IRequestHandler<HistoricoRequest, List<HistoricoResponse>>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;

        public async Task<List<HistoricoResponse>> Handle(HistoricoRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticacao.PegarId());
            int numeroDaPagina = request.NumeroDaPagina;

            Operacao operacao = new();

            List<Operacao> lista = operacao.Historico(id, numeroDaPagina, _repositorioOperacao, cancellationToken);
            IEnumerable<Task<HistoricoResponse>> tasks = lista.Select(async x => new HistoricoResponse
            {
                Valor = x.Valor,
                TipoOperacao = x.TipoOperacao.ToString(),
                CpfDestino = x.TipoOperacao.ToString() == Transacoes.Transferencia.ToString() ? await _repositorioConta.PegarCpf(x.IdContaDestino, cancellationToken) : null,
                DataOperacao = x.DataOperacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:hh"),
                Descricao = x.Descricao
            });

            var resultados = await Task.WhenAll(tasks);

            return new List<HistoricoResponse>(resultados);
        }
    }
}