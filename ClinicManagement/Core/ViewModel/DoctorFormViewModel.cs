using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.ViewModel
{
    public class DoctorFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsAvailable { get; set; }


        [Required]
        public int Specialization { get; set; }

        public IEnumerable<Specialization> Specializations { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }


        //public string Heading
        //{
        //    get
        //    {
        //        return Id != 0 ? "Edit Doctor" : "New Doctor";
        //    }
        //}
        //public DoctorFormViewModel()
        //{
        //    Id = 0;
        //}
        //public DoctorFormViewModel(Doctor doctor)
        //{
        //    Id = doctor.Id;
        //    Name = doctor.Name;
        //    Phone = doctor.Phone;
        //    Specialization = doctor.SpecializationId;

        //}

    }
}



//public string Action
//{
//    get
//    {
//        Expression<Func<AccountController, ActionResult>> update = (c => c.Update(this));
//        Expression<Func<AccountController, ActionResult>> create = (async c => await c.Create(this));
//        var action = (Id != 0) ? update : create;
//        return (action.Body as MethodCallExpression).Method.Name;
//    }
//}
