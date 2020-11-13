import React from 'react';
import styles from './CreateBook.module.css';
import {CreateBookForm} from '../../../../components/forms/create-book-form';

export const CreateBook = () => {
  return (
    <div className={styles.wrapper}>
      <h2>Create book</h2>
      <CreateBookForm />
    </div>
  );
}