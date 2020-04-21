using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.Unban
{
    public class UnbanUserCommandHandler : IRequestHandler<UnbanUserCommand>
    {
        public Task<Unit> Handle(UnbanUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
