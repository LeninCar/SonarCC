import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <h1>Gestor de Proyectos</h1>
        <p>
          ¡Bienvenido al Gestor de Proyectos! Empieza a organizar tus tareas y proyectos de manera eficiente.
        </p>
        <div className="button-container">
          <button className="App-button">Crea tu proyecto</button>
          <button className="App-button">Únete</button>
        </div>
        <a
          className="App-link"
          href="https://github.com/LeninCar/Gestor"
          target="_blank"
          rel="noopener noreferrer"
        >
          Nuestro repo
        </a>
      </header>
    </div>
  );
}

export default App;