import React, {useEffect, useState} from 'react';
import {useParams} from 'react-router-dom';
import {BookItem} from '../../components/common/book-item';
import styles from './BookPage.module.css';
import Card from '@material-ui/core/Card';
import axios from 'axios';
export const BookPage = () => {
  let { id } = useParams();
  const bookId = parseInt(id);
  const [book, setBook] = useState(null);

  const reserveBook = (bookId)=> {
    axios({
      method: 'POST',
      url : `/api/booking`,
      data: bookId
    });
  }

  useEffect(() => {
    axios.get(`/api/book/${bookId}`).then(response=> {
      setBook(response.data);
    }).catch(err => {
      console.log(err);
    });
  }, [id])

  return (
    <Card className={styles.wrapper}>
      <BookItem onBook={reserveBook} book={book} id={id}/>
    </Card>
  );
}