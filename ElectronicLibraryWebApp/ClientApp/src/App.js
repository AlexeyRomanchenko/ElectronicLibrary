import {Header} from './components/Header';
import {Home, SignIn} from './pages';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

const App = () => {
  return (<Router>
      <Header/>
      <Switch>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
