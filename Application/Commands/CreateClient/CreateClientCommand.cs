using MediatR;

namespace Application.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
