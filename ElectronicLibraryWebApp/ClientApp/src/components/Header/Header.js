import React , {useState} from 'react';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import {Link} from 'react-router-dom';
import {Search} from '../search';
import styles from './Header.module.css';
import axios from 'axios';
import Icon from '@material-ui/core/Icon';

const useStyles = makeStyles((theme) => ({
  root: {
        flexGrow: 1
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
}));

export const Header = () => {
    const classes = useStyles();
    const [isVisible, setVisibility] = useState(false);
    const [books, setBooks] = useState([]);

    const onSearch = (event) => {
        const key = event.target.value;     
        if (key.length > 0) {
            axios({
                method: 'GET',
                url: `/api/search/${event.target.value}`
            }).then(response => {
                setBooks(response.data);
                response.data.length > 0 ? setVisibility(true) : setVisibility(false);
            }).catch(err => {
                console.error(err);
            });
        }
        else{
          setVisibility(false);
        }
    }
    const hide = ()=> {
      setVisibility(false);
    }

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar>
          <Typography variant="h6" className={classes.title}>
            <Link className={styles.logo} to="/">E-Library</Link>
          </Typography>

           <Search hide={hide} books={books} isVisible={isVisible} onSearch={onSearch}/>
                  <div className={styles.btn__wrapper}>
                      <Icon className="fa fa-plus-circle" />
                      <Link to="/dashboard">Cabinet</Link>
                      <Link to="/signin">Login</Link>
                      <Link to="/signup">Register</Link>
                  </div>
        </Toolbar>
      </AppBar>
    </div>
  );
}