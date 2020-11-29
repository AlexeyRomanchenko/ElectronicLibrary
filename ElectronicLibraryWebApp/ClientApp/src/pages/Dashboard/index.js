import {Main} from './Main';
import React from 'react';
import {CreateBook} from './Books/Create';
import {
    Switch,
    Route,
    useRouteMatch
  } from "react-router-dom";
import { BottomNav } from '../../components/common/bottom-navigation/BottomNav';
import { BookList } from './Books/BookLIst';
import styles from './Dashboard.module.css';
import { BookingList } from './Bookings';
import { UserList } from './Users';

export const Dashboard = () => {
    let { path } = useRouteMatch();
    return(
      <>
      <div className={styles.wrapper}>
        <Switch>
        <Route exact path={path}>
            <Main />
        </Route>
        <Route exact={true} path={`${path}/books/create`}>
          <CreateBook />
        </Route>
        <Route exact={true} path={`${path}/books`}>
          <BookList />
        </Route>
        <Route exact={true} path={`${path}/bookings`}>
          <BookingList />
        </Route>
        <Route exact={true} path={`${path}/users`}>
          <UserList />
        </Route>
      </Switch>
    </div>
      <BottomNav path={path}/>
    </>
    );

}