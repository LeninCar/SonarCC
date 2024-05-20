using backend_todo.Models;
using System.Runtime.Serialization;

namespace TestGestor
{
    public class EstadoTareaTests
    {
        [Theory]
        [InlineData(EstadoTarea.Pendiente, "Idea Viable")]
        [InlineData(EstadoTarea.EnProceso, "En Proceso")]
        [InlineData(EstadoTarea.Terminada, "Terminada")]
        public void EstadoTarea_ShouldHaveCorrectEnumMemberValues(EstadoTarea estado, string expectedValue)
        {
            // Act
            var enumType = typeof(EstadoTarea);
            var enumMember = enumType.GetMember(estado.ToString())[0];
            var enumValue = ((EnumMemberAttribute)enumMember.GetCustomAttributes(typeof(EnumMemberAttribute), false)[0]).Value;

            // Assert
            Assert.Equal(expectedValue, enumValue);
        }
    }
}