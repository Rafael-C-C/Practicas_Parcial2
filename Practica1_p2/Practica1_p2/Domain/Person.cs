using System;

namespace QueryApi.Domain
{
    //Variables para la consulta de datos
    public record Person(int Id, string FirstName, string LastName, string Email, char Gender, string Job, int Age);
}