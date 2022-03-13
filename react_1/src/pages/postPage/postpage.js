import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

export default function HomePage() {
  const [data, setData] = useState([]);
  const [searchText, setSearchText] = useState('');
  const token = localStorage.getItem('token');
  
  
  const [sortByTitle, setSortByTitle] = useState(null);
  
  const postsFiltered = data.filter(row => row.title.toLowerCase().includes(searchText.toLowerCase()));
  const getPostsSorted = () => {
    if (sortByTitle === null) return postsFiltered;
    return postsFiltered.sort((post1, post2) => {
      if (sortByTitle === 'ASC') return post1.title.localeCompare(post2.title)
      else return post2.title.localeCompare(post1.title)
    });
  }

  const postsSorted = getPostsSorted();
  useEffect(() => {
    const header = {};
    if (token) {
      header['Authorization'] = token;
    }

    fetch('https://jsonplaceholder.typicode.com/posts', {
      method: 'GET',
      headers: header
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (json) {
        setData(json);
      });
  }, [token]);
  
  const RemoveRow = postId => {
    const index = data.findIndex(row => row.id === postId);
    const newDatas = [...data];
    newDatas.splice(index, 1);
    setData(newDatas);
  };
 
  
  
  return (
    <div>
      <input
        type="text"
        placeholder="Search by title"
        className="search-by-title"
        value={ searchText }
        onChange={ evt => setSearchText(evt.target.value) }
      />
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th onClick={ () => {
            if (sortByTitle === null) setSortByTitle('ASC');
            if (sortByTitle === 'ASC') setSortByTitle('DES');
            if (sortByTitle === 'DES') setSortByTitle(null);
          } }>Title -- Sort { sortByTitle === null ? '(NONE)' : sortByTitle }
          </th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        {postsSorted.map((row) => (
          <tr key={row.id}>
            <td>{row.id}</td>
            <td>{row.title}</td>
            <td>
              <Link to={`/post/${row.id}`}>View detail</Link> 
              <button style={ { marginLeft: 15 } } onClick={ () => RemoveRow(row.id) }>Remove</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
    </div>
  );
}
