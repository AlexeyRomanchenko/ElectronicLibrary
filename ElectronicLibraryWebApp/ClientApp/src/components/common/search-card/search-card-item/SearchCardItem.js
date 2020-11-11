import React from 'react';
import styles from './SearchCardItem.module.css';
import {Link} from 'react-router-dom';

export const SearchCardItem = ({book, hide}) => {
  return (
    <div className={styles.wrapper}>
    <h5><Link onClick={hide} className={styles.search_card__link} to={`/book/${book.id}`} >{book.name}</Link></h5>
    </div>)
}