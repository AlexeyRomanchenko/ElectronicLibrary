import React from 'react';
import Button from '@material-ui/core/Button';
import {CommentForm, CommentList} from '../../comments';
import styles from './BookItem.module.css';
export const BookItem = ({book, onBook}) => {
  if(book!=null)
  {
    return (
      <div className={styles.wrapper}>
        <div className={styles.book__img_container}>
          <img src={book.imagePath} alt={book.name}/>
        </div>
        <div className = {styles.book__description_container}>
          <h2>Name: {book.name}</h2>
          <p>Author: {book.author.firstname} {book.author.lastname}</p>
          <p>Release year: {new Date(book.publishYear).getFullYear()}</p>
          <Button onClick={() => onBook(book.id)} variant="outlined" color="primary">Book</Button>
        </div>
        <div className={styles.hr}></div>
        <div className={styles.comments__wrapper}>
          <h3>Comments</h3>
          <h5>You can leave a comment to this book:</h5>
          <CommentForm/>
          <CommentList comments={book.comments}/>
        </div>
      </div>
    );
  }
  else
  {
    return (<p>loading...</p>);
  }

}