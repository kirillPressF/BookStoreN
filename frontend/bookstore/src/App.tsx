
import './App.css'
import Layout, { Content, Header, Footer } from 'antd/es/layout/layout'
import { Menu } from 'antd'
import { Link, Outlet } from 'react-router-dom';
import './global.css'

const items = [
  { key: "home", label: <Link to={'/'}>Home</Link> },
  { key: "books", label: <Link to={'/Books'}>Books</Link> },
]

const header = () => (

  <Header>
    <Menu
      theme="dark"
      mode="horizontal"
      items={items}
      style={{ flex: 1, minWidth: 0 }}
    />
  </Header>
)
const footer = () => (
  <Footer style={{
    textAlign: 'center',
    backgroundColor: '#001529',
    color: 'rgba(255, 255, 255, 0.65)',
  }}>
    BookStore created 2024
  </Footer>
)


function App() {

  return (
    <>
      <Layout style={{ minHeight: "100vh", minWidth: '100vw', backgroundColor: 'white' }}>
        {header()}
        <Content style={{ padding: "0 48px" }}>
          <Outlet />
        </Content>
        {footer()}
      </Layout>
    </>
  )
}


export default App
