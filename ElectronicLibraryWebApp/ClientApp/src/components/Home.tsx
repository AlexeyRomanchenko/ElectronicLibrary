import { Card } from '@material-ui/core';
import * as React from 'react';
import { connect } from 'react-redux';
import { BookCard } from './common/book-card/BookCard';

const Home = () => (
  <div>
    <h1>Hello, world!</h1>
    <BookCard/>
    
  </div>
);

export default connect()(Home);
