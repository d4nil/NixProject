using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core
{
    public class UserData 
    {
        public Guid UserDataId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public City City { get; set; }

        public UserData( string name, string p, string e, string c)
        {
            Name = name;
            List<Phone> Phones = new ();
            Phones.Add(new Phone { phone = p });
            List<Email> Emails = new ();
            Emails.Add(new Email { email = e });
            City = new City { city = c };
        }
        public UserData() { }
        public void ChangeEmail(string em)
        {
            foreach (Email e in Emails)
            {
                if (e.email == null) { Emails.Add(new Email { email = em }); break; }
                else e.email = em; break;
            }

        }
        public void ChangePhone(string ph)
        {
            foreach (Phone p in Phones)
            {
                if (p.phone == null) { Phones.Add(new Phone { phone = ph }); break; }
                else p.phone = ph; break;
            }
        }
        public void ChangeCity(string ct)
        {
            if (City == null)
            {City = new City { city = ct }; }
            else { City.city = ct; }
        }
    }
}
