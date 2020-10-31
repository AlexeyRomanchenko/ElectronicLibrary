import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
export const NavMenu = () => {
        return (
            <header>
            <AppBar style={{background:'#313FA0'}} position="static">
            <Toolbar>
              <Typography variant="h6">
                Electronic Library
              </Typography>
              <Button color="inherit">Login</Button>
            </Toolbar>
          </AppBar>
            </header>
        );
}
