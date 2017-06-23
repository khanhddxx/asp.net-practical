
namespace eLink.Membership
{
    using Serenity.ComponentModel;
    using Serenity.Services;

    [FormScript("Membership.Login")]
    [BasedOnRow(typeof(Administration.Entities.UserRow))]
    public class LoginRequest : ServiceRequest
    {
        [Placeholder("")]
        public string Username { get; set; }
        [PasswordEditor, Placeholder(""), Required(true)]
        public string Password { get; set; }
    }
}