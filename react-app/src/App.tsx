import './App.css';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { Orders } from "./components/Orders";
import { Shop } from "./components/Shop";
import { Navbar } from "./components/Navbar";
import React, { Fragment } from "react";

function App(): JSX.Element {
  return (
    <Fragment>
      <Navbar />
      <Routes>
        <Route path="/" element={<Shop />} />
        <Route path="/orders" element={<Orders />} />
      </Routes>
    </Fragment>
  );
}

export default App;
