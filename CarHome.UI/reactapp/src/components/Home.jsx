import React from 'react';

const chromelylogo = require('./../assets/img/chromely_gray.png');
const reactlogo = require('./../assets/img/logo.svg');

function Home() {
  return (
    <div className="container-fluid">
      <div className="row ">
        <div className="col-12">
          <div className="text-center m-0  d-flex flex-column justify-content-center">
            <div>
              <div class="row justify-content-center">
                <div class="justify-content-right">
                  <img src={chromelylogo} className="img-rounded spacer25" alt="Cinque Terre" width="160" height="160" />
                </div>
                <div class="justify-content-left">
                  <img src={reactlogo} className="img-rounded" alt="Cinque Terre" width="240" height="240" />
                </div>
              </div>

              <div>
                <span className="text-primary text-center"><h2>chromely react</h2></span>
              </div>
              <div>
                <p className="text-muted text-center">Build .NET/.NET CORE HTML5 Desktop Apps</p>
              </div>
              <div>
                <p></p>
              </div>
              <div className="container col-8 justify-content-center">
                <ul className="list-group">
                  <li className="list-group-item d-flex justify-content-between align-items-center">
                  </li>
                  <li className="list-group-item d-flex justify-content-between align-items-center">
                  </li>
                  <li className="list-group-item d-flex justify-content-between align-items-center">

                  </li>
                </ul>
              </div>
              <div>
                <p></p>
              </div>
              <div>
                <p></p>
              </div>
              <div>
                <a href="https://github.com/chromelyapps/Chromely" className="btn btn-default" role="button" style={{ margin: '5px' }} >more info</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Home;