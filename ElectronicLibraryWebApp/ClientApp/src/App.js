import {Header} from './components/Header';
import {BookPage, Home, SignIn, SignUp} from './pages';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import { CreateBook } from './pages/Dashboard/Books/Create/CreateBook';

const App = () => {
  return (<Router>
      <Header/>
      <Switch>
          <Route path="/signin">
            <SignIn />
          </Route>
          <Route path="/dashboard">
            <CreateBook />
          </Route>
          <Route path="/signup">
            <SignUp />
          </Route>
          <Route path="/book/:id">
          < BookPage />
        </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
