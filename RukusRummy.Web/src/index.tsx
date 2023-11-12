import React from 'react';
import ReactDOM from 'react-dom/client';
import reportWebVitals from './reportWebVitals';
import {
  BrowserRouter
} from "react-router-dom";
import { Provider } from 'react-redux';

import Layout from './Components/Layout';
import { ApiProvider } from './Contexts/ApiContext';
import { AppSateProvider } from './Contexts/AppContext';
// import store from './Store/Store';

import './index.scss';
import { GameHubProvider } from './Contexts/GameHubContext';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
)

root.render(
  <React.StrictMode>
    {/* <Provider store={store}> */}
      <ApiProvider>
        <AppSateProvider>
          <GameHubProvider>
            <BrowserRouter>
              <Layout />
            </BrowserRouter>
          </GameHubProvider>
        </AppSateProvider>
      </ApiProvider>
    {/* </Provider> */}
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
