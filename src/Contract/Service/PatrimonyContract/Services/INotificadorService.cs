using SGP.Model.Entity;
using System.Collections.Generic;

namespace SGP.Contract.Service.PatrimonyContract
{
    public interface INotificadorService
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
