import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import styles from './NavMenu.module.css';

export const NavMenu = () => {
        return (
            <header>
            <AppBar style={{background:'#251C65'}} position="static">
            <Toolbar>
              <Typography variant="h6">
                Electronic Library
              </Typography>
              <div className={styles.btn__wrapper}>
                <Button color="inherit">Login</Button>
              </div>
            </Toolbar>
          </AppBar>
            </header>
        );
}
