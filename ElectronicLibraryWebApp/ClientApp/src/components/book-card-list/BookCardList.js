import React from 'react';
import {BookCard} from '../common/book-card';
import styles from './BookCardList.module.css';
 
export const BookCardList = () => {
    const getBooks = () => {
        const books = [
            {id:8},
            {id: 10}
        ];
        const cards = books.map(book => (<BookCard key={book.id}/>));
        return cards;
    }
    return (<div className={styles.wrapper}>
        {
           getBooks()
        }
        </div>);
}