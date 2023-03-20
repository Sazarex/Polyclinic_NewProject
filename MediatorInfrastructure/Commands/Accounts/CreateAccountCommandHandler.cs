using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MediatorInfrastructure.Commands.Accounts
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
