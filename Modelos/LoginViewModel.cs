using System.ComponentModel.DataAnnotations;

namespace BackendLearningHub.Modelos;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o e-mail.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail valido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
