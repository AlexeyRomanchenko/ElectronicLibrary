import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles({
  root: {
    maxWidth: 345,
  },
});

export const BookCard = () => {
  const classes = useStyles();

  return (
    <Card className={classes.root}>

        <CardMedia
          component="img"
          alt="book name"
          height="300"
          image="https://d1csarkz8obe9u.cloudfront.net/posterpreviews/fairytale-old-vintage-book-cover-template-design-5ff0b48b07be66f694dcd67101cefa12_screen.jpg?ts=1566579743"
          title="book name"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            Lizard
          </Typography>
        </CardContent>
      <CardActions>
        <Button size="small" color="primary">
          Learn More
        </Button>
      </CardActions>
    </Card>
  );
}