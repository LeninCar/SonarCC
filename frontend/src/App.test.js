import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

describe('App', () => {
  it('renders without crashing', () => {
    render(<App />);
    // Check if the component renders without crashing
  });

  it('renders header with correct text', () => {
    render(<App />);
    expect(screen.getByText('Gestor de Proyectos')).toBeInTheDocument();
  });

  it('renders paragraph with correct text', () => {
    render(<App />);
    expect(screen.getByText('¡Bienvenido al Gestor de Proyectos! Empieza a organizar tus tareas y proyectos de manera eficiente.')).toBeInTheDocument();
  });

  it('renders buttons with correct text and class', () => {
    render(<App />);
    const createProjectButton = screen.getByText('Crea tu proyecto');
    const joinButton = screen.getByText('Únete');

    expect(createProjectButton).toBeInTheDocument();
    expect(createProjectButton).toHaveClass('App-button');

    expect(joinButton).toBeInTheDocument();
    expect(joinButton).toHaveClass('App-button');
  });

  it('renders link with correct URL', () => {
    render(<App />);
    const repoLink = screen.getByText('Nuestro repo');
    expect(repoLink).toBeInTheDocument();
    expect(repoLink.href).toBe('https://github.com/LeninCar/Gestor');
    expect(repoLink.target).toBe('_blank');
  });
});