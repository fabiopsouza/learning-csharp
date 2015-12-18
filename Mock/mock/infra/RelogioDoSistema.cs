using System;

namespace mock.infra
{
    public class RelogioDoSistema : IRelogio
    {

        public DateTime hoje()
        {
            return DateTime.Today;
        }
    }
}