namespace API.Entities
{
    public class AppUser
    {    //Public - means property can be get or set by any class in the application
        //Protected - accessed by this class or any that inherit
        //Private - property is only accessible from this class


        //Entity framework will recgonise that 'Id' is the primary key of our database
        public int Id { get; set; } //Id property
        public string UserName { get; set; } //Using ASP.Net Core Identity, uses a username with an uppercase 'N' - less refactorin
    }
}