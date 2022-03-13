import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

export default function PostDetailPage() {
  const postId = useParams().id;
  const [data, setData] = useState({});

  const token = localStorage.getItem('token');

  useEffect(() => {
    const header = {};
    if (token) {
      header['Authorization'] = token;
    }

    fetch(`https://jsonplaceholder.typicode.com/posts/${postId}`, {
      method: 'GET',
      headers: header,
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (json) {
        setData(json);
      });
  }, [token])

  return (
    <div>
      ID: {data?.id}<br />
      Title: {data?.title}<br />
      Body: {data.body}
    </div>
  )
}