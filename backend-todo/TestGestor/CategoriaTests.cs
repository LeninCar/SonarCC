using backend_todo.Models;

namespace TestGestor
{
    public class CategoriaTests
    {
        [Fact]
        public void Categoria_ShouldInitializeWithEmptyTareas()
        {
            // Arrange & Act
            var categoria = new Categoria();

            // Assert
            Assert.NotNull(categoria.Tareas);
            Assert.Empty(categoria.Tareas);
        }
    }
}