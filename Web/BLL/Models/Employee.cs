using System;

namespace Web.BLL.Models

{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfHire { get; set; }
        public string Position { get; set; }
    }
}