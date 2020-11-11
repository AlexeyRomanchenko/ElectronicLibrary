import React, {useEffect} from 'react';
import { Paper } from '@material-ui/core';
import {SearchCardItem} from './search-card-item';
import styles from './SearchCard.module.css';

export const SearchCard = ({books, hide}) => {
  useEffect(()=> {
  console.log(`Books`, books);
  }, [books]);

  return (<>
    <Paper className={styles.search__content} elevation={1}>
    {books.map(book=> {
      return <SearchCardItem hide={hide} book={book} />
    })}
    </Paper>
  </>)
}