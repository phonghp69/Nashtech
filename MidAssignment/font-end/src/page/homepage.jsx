import React from 'react';
import '../style.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Row, Col, Card } from "react-bootstrap";
export default function HomePage() {
  
  return (

    <div>
      <section class="jumbotron text-center">
        <div class="container">
          <h1 class="jumbotron-heading">Library</h1>
          <p class="lead text-muted">Ét ô Ét</p>
        </div>
      </section>

      <div class="album py-5 bg-light">
        <div class="container">

          <div class="row">
            <Row xs={1} md={6} className="g-4">
              {Array.from({ length: 20 }).map((_, idx) => (
                <Col>
                  <Card>
                    <img variant="top" src="https://bloganchoi.com/wp-content/uploads/2021/11/game-dragon-ball-1.jpg" />
                    <Card.Body>
                      <Card.Title>Dragon Ball</Card.Title>
                      <Card.Text>
                        Songoku
                      </Card.Text>
                      <div class="btn-group">
                      <button type="button" class="btn btn-sm btn-outline-secondary">Borrow</button> 
                    </div>
                    </Card.Body>
                  </Card>
                </Col>
              ))}
            </Row>
          </div>
        </div>
      </div>
    </div>
  )
} 
