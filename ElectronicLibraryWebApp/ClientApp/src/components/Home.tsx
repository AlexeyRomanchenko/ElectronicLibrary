import * as React from 'react';
import { connect } from 'react-redux';
import { BookCardList } from './book-card-list';

const Home = () => (
  <div style={{background: '#F5F8F9'}}>
  <div style={{ margin: '0 auto', maxWidth:'60rem'}}>
    <h1>Hello, world!</h1>
    <BookCardList/>
    </div>
  </div>
);

export default connect()(Home);
