using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Giftins.Application.Account.Remove
{
    public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommand>
    {
        public Task<Unit> Handle(RemoveAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
