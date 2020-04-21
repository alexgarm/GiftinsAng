using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.Ban
{
    public class BanUserCommandHandler : IRequestHandler<BanUserCommand>
    {
        public Task<Unit> Handle(BanUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
