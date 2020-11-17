import React from 'react';
import styles from './CreateBook.module.css';
import {CreateBookForm} from '../../../../components/forms/create-book-form';
import { Card } from '@material-ui/core';

export const CreateBook = () => {
  return (
    <Card className={styles.wrapper}>
      <h2>Create book</h2>
      <CreateBookForm />
    </Card>
  );
}