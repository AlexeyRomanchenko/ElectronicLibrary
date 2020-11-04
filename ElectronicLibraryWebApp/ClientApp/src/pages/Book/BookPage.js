import { StylesProvider } from '@material-ui/core';
import React from 'react';
import {useParams} from 'react-router-dom';
import styles from './BookPage.module.css';
import Card from '@material-ui/core/Card';
export const BookPage = () => {
  let { id } = useParams();
  return (
    <Card  className={styles.wrapper}>Book item {id}</Card>
  );
}