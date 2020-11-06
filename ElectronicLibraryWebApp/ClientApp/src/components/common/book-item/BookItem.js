import React from 'react';
import Button from '@material-ui/core/Button'
import styles from './BookItem.module.css';
export const BookItem = () => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.book__img_container}>
        <p>Image</p>
      </div>
      <div className = {styles.book__description_container}>
        <h2>Book name</h2>
        <p>Author</p>
        <p>Publish year</p>
        <Button>Book</Button>
      </div>
    </div>
  );
}