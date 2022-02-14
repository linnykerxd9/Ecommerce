namespace Ecommerce.Service.DTO
{
    public class CostumerDTO : EntityDTO
    {
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public EmailDTO Email { get; set; }

        public CostumerDTO(string fullName, string cpf, EmailDTO email)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
        }
    }
}