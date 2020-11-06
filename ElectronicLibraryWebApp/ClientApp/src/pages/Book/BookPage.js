import React, {useEffect} from 'react';
import {useParams} from 'react-router-dom';
import {BookItem} from '../../components/common/book-item';
import styles from './BookPage.module.css';
import Card from '@material-ui/core/Card';
import axios from 'axios';
export const BookPage = () => {
  let { id } = useParams();
  const bookId = parseInt(id);
  useEffect(() => {
    console.log(bookId);
    axios.get(`/api/book/${bookId}`).then(data=> {
      console.log('received book item', data);
    }).catch(err => {
      console.log(err);
    });
  }, [id])

  return (
    <Card className={styles.wrapper}>
      <BookItem id={id}/>
    </Card>
  );
}