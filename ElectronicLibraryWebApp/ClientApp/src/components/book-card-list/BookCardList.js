import axios from 'axios';
import React ,{useEffect, useState} from 'react';
import {BookCard} from '../common/book-card';
import styles from './BookCardList.module.css';
 
export const BookCardList = () => {
    const [books, setBooks] = useState([]);
    useEffect(()=> {
        axios.get('/api/book')
        .then(response=> {
            const books = response.data;
            setBooks(books); 
        }).catch(err=>{
            console.log(err);
        });
         
    }, []);
    const getBooks = () => {
        const cards = books.map(book => (<BookCard book ={book} key={book.id}/>));
        return cards;
    }
    return (<div className={styles.wrapper}>
        {
           getBooks()
        }
        </div>);
}