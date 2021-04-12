import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';


class GetResultsComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      currentPage: 1,
      linkPerPage: 3,
      query: '',
      links:[]        
    };
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick(event) {
    this.setState({
      currentPage: Number(event.target.id)
    });
  }

  handleInputChanged(event) {
    this.setState({
      query: event.target.value
    });
  }

  handleButtonClicked() {
    var url = new URL("https://localhost:44381/api/Values/GetResults/" + this.state.query);    

    fetch(url)
    .then(res => res.json())
    .then(
      (result) => {    
        //alert(JSON.stringify(result));
        this.setState({
          links: result
        });                
      }
    );
  }
  
//componentDidMount() {
//}

render() {
  const { links, currentPage, linkPerPage } = this.state;

  // Links
  const indexOfLastLink = currentPage * linkPerPage;
  const indexOfFirstLink = indexOfLastLink - linkPerPage;
  const currentLink = links.slice(indexOfFirstLink, indexOfLastLink);

  const renderLink = currentLink.map((links, index) => {
    return <p><a href={links.link} key={index}> {links.title} </a></p>;
  });

  // Numbers
  const pageNumbers = [];
  for (let i = 1; i <= Math.ceil(links.length / linkPerPage); i++) {
    pageNumbers.push(i);
  }

  const renderPageNumbers = pageNumbers.map(number => {
    return (
      <button
        key={number}
        id={number}
        onClick={this.handleClick}
      >
        {number}
      </button>
    );
  });

  return (
    <div>
    <ul>
    <h2>Search</h2>    
    <input type="text" value={this.state.searchQuery} onChange={this.handleInputChanged.bind(this)}/>
    <button onClick={this.handleButtonClicked.bind(this)}>Submit</button>
    </ul>
      <ul>
        {renderLink}
      </ul>
      <ul id="page-numbers">
        {renderPageNumbers}
      </ul>
    </div>
  );
}
}

  const element=<GetResultsComponent></GetResultsComponent>
  ReactDOM.render(element,document.getElementById("root"));
  
    
// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
