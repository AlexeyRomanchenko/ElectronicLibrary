import React, { useEffect } from 'react';
import {SearchForm} from '../forms/search-form';
import {SearchCard} from '../common/search-card';
import styles from './Search.module.css';

export const Search = ({onSearch, isVisible, books}) => {
  useEffect(()=> {
    console.log(`isVisible`, isVisible);
  }, [isVisible]);

  return (
  <div className={styles.wrapper}>
    <SearchForm onSearch={onSearch}/>
    {isVisible ?  <SearchCard books = {books}/> : <></>}
    
  </div>
  )
}