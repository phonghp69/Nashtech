import React from 'react';
import '../style.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Row, Col, Card } from "react-bootstrap";
export default function CategoryPage() {
  return (

          <div class="row">
            <Row xs={1} md={6} className="g-4">
              {Array.from({ length: 20 }).map((_, idx) => (
                <Col>
                  <Card>                   
                    <Card.Body>
                      <Card.Title>Dragon Ball</Card.Title>
                      <div class="btn-group">
                      <button type="button" class="btn btn-sm btn-outline-primary">View</button>
                      
                    </div>
                    </Card.Body>
                  </Card>
                </Col>
              ))}
            </Row>
          </div>
      
  )
} 
