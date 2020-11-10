import React from 'react';
import axios from 'axios';
import InputBase from '@material-ui/core/InputBase';
import styles from './SearchForm.module.css';

export const SearchForm = () => {
    const onSearch = (event) => {
      const key = event.target.value;
      if(key.length > 0)
      {
        axios({
          method: 'GET',
          url:`/api/search/${event.target.value}`
        }).then(response=> {
          console.log(response.data);
        }).catch(err=> {
          console.error(err);
        });
      }
    }

    return (
        <InputBase
        onChange ={onSearch}
        className={styles.search_bar}
        placeholder="Search books"
        inputProps={{ 'aria-label': 'search google maps' }}
      />
    );
}