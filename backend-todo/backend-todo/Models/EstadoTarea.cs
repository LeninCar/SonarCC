using System.Runtime.Serialization;

namespace backend_todo.Models
{
    public enum EstadoTarea
    {
        [EnumMember(Value = "Idea Viable")]
        Pendiente,
        [EnumMember(Value = "En Proceso")]
        EnProceso,
        [EnumMember(Value = "Terminada")]
        Terminada
    }
}
