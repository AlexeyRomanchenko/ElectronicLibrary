import React from 'react';
import {BookCardList} from '../../components/book-card-list';
import styles from './Home.module.css';

export const Home = () => {

  return (
    <div className={styles.wrapper}>
      <BookCardList/>
    </div>);
}