﻿using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Buscar
{
    public sealed record BuscarRequest : IRequest<BuscarResponse>
    {
    }
}