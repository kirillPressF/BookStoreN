import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import Books from './pages/books/Books.tsx';
import ErrorPage from './pages/errorPage.tsx';
import Home from './pages/Home.tsx'

const router = createBrowserRouter([
  {
    path: '/',
    element: <App/>,
    errorElement: <ErrorPage />,
    children: [
      {
        index: true, element: <Home/>,
      },
      {
        path: '/Books',
        element: <Books/>,
        errorElement: <ErrorPage />,
      },
    ]
  },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
      <RouterProvider router = {router}/>
  </React.StrictMode>,
)

