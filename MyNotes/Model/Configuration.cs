
namespace MyNotes.Model
{
    public class Configuration : BaseModel
    {

        public byte[] Password {get; set;}

        public void SetPassword(string password)
        {
            this.Password = System.Text.Encoding.UTF8.GetBytes(password);
        }

        public Configuration()
        {
            this.Id = null;
        }
    }
}
