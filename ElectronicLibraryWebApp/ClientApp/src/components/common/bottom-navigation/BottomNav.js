import React from 'react';
import BottomNavigation from '@material-ui/core/BottomNavigation';
import BottomNavigationAction from '@material-ui/core/BottomNavigationAction';
import BookIcon from '@material-ui/icons/Book';
import ShopIcon from '@material-ui/icons/Shop';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import EventIcon from '@material-ui/icons/Event';
import styles from './BottomNav.module.css';
import { Link } from 'react-router-dom';

export const BottomNav = ({path}) => {
    const [value, setValue] = React.useState(0);
  
    return (
      <BottomNavigation
       
        className={styles.nav}
        value={value}
        onChange={(event, newValue) => {
          setValue(newValue);
        }}
        showLabels
      >

            <BottomNavigationAction
        component={Link}
        to={`${path}/books`}
        label="Books" icon={<BookIcon />} />

            <BottomNavigationAction
        component={Link}
        to={`${path}/bookings`}
        label="Bookings" icon={<ShopIcon />} />

            <BottomNavigationAction
        component={Link}
        to={`${path}/users`}
        label="Users" icon={<AccountCircleIcon />} />

            <BottomNavigationAction
        component={Link}
        to={`${path}/logs`}
        label="Logs" icon={<EventIcon />} />
      </BottomNavigation>
    );
}